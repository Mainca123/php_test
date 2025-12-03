FROM php:8.2.11-apache

ARG DOWNLOAD_URL
ARG FOLDER

ENV DIR_OPENCART="/var/www/html/"
ENV DIR_STORAGE="/storage/"
ENV DIR_IMAGE="${DIR_OPENCART}image/"

# Basic packages
RUN apt-get clean && apt-get update && apt-get install -y unzip vim curl

# PHP extensions (gd, zip, mysqli)
RUN apt-get install -y \
    libfreetype6-dev \
    libjpeg62-turbo-dev \
    libpng-dev \
    libzip-dev \
    && docker-php-ext-configure gd --with-freetype --with-jpeg \
    && docker-php-ext-install -j"$(nproc)" gd zip mysqli

# Storage folders
RUN mkdir -p /storage && mkdir -p /opencart

# Download OpenCart (latest version or DOWNLOAD_URL)
RUN if [ -z "$DOWNLOAD_URL" ]; then \
        curl -Lo /tmp/opencart.zip $(curl -s https://api.github.com/repos/opencart/opencart/releases/latest \
        | grep "browser_download_url" | cut -d : -f 2,3 | tr -d "\""); \
    else \
        curl -Lo /tmp/opencart.zip ${DOWNLOAD_URL}; \
    fi

# Extract OpenCart
RUN unzip /tmp/opencart.zip -d /tmp/opencart

# Move upload folder into web root
RUN mv /tmp/opencart/$(if [ -n "$FOLDER" ]; then echo $FOLDER; \
        else unzip -l /tmp/opencart.zip | awk '{print $4}' | grep -E 'opencart-[0-9\.]+/upload/$'; \
        fi)* ${DIR_OPENCART}

# Clean installer (OpenCart 4.x)
RUN rm -rf /tmp/opencart.zip /tmp/opencart ${DIR_OPENCART}install

# OpenCart 4.x does NOT have system/storage — skip move
RUN echo "OpenCart 4.x detected — skipping move storage step"

# Copy your config + php.ini
COPY configs ${DIR_OPENCART}
COPY upload/php.ini ${PHP_INI_DIR}

# Enable mod_rewrite for SEO URLs
RUN a2enmod rewrite

CMD ["apache2-foreground"]
