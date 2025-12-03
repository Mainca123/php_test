FROM php:8.2.11-apache

# Cho phép truyền URL custom nếu muốn
ARG DOWNLOAD_URL

ENV DIR_OPENCART="/var/www/html"
ENV DIR_STORAGE="/storage"
ENV DIR_IMAGE="${DIR_OPENCART}/image"

# Cài package cần thiết
RUN set -eux; \
    apt-get update; \
    apt-get install -y --no-install-recommends \
        unzip \
        curl \
        libfreetype6-dev \
        libjpeg62-turbo-dev \
        libpng-dev \
        libzip-dev; \
    rm -rf /var/lib/apt/lists/*

# Cài extension PHP
RUN set -eux; \
    docker-php-ext-configure gd --with-freetype --with-jpeg; \
    docker-php-ext-install -j"$(nproc)" gd zip mysqli

# Tạo thư mục
RUN mkdir -p "${DIR_STORAGE}" /opencart

# -------------------------------
# TẢI OPENCART (ĐÃ FIX curl)
# -------------------------------
RUN set -eux; \
    if [ -z "$DOWNLOAD_URL" ]; then \
        OC_URL=$(curl -s https://api.github.com/repos/opencart/opencart/releases/latest \
            | grep browser_download_url \
            | grep upload.zip \
            | head -n1 \
            | cut -d '"' -f 4); \
        echo "Downloading OpenCart from: ${OC_URL}"; \
        curl -L -o /tmp/opencart.zip "${OC_URL}"; \
    else \
        echo "Downloading OpenCart from custom URL: ${DOWNLOAD_URL}"; \
        curl -L -o /tmp/opencart.zip "${DOWNLOAD_URL}"; \
    fi; \
    unzip /tmp/opencart.zip -d /tmp/opencart; \
    UPLOAD_DIR=$(find /tmp/opencart -maxdepth 1 -type d -name "opencart-*"); \
    echo "Using upload dir: ${UPLOAD_DIR}"; \
    # Xóa file mặc định trong /var/www/html cho sạch
    rm -rf "${DIR_OPENCART:?}/"*; \
    # Move mã nguồn OpenCart vào webroot
    mv "${UPLOAD_DIR}/upload/"* "${DIR_OPENCART}/"; \
    # Xóa thư mục cài đặt (install)
    rm -rf /tmp/opencart /tmp/opencart.zip "${DIR_OPENCART}/install"

# Bật mod_rewrite (SEO URL)
RUN a2enmod rewrite

# Copy config của bạn (nếu có)
# Thư mục configs phải tồn tại trong project của bạn
COPY configs/ "${DIR_OPENCART}/"

# Copy php.ini custom (nếu có)
# File upload/php.ini phải tồn tại trong project
COPY upload/php.ini "${PHP_INI_DIR}/conf.d/opencart.ini"

# Mặc định php:apache đã có CMD này,
# nhưng mình ghi rõ cho dễ đọc
CMD ["apache2-foreground"]
