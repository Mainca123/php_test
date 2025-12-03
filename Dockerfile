FROM php:8.2.11-apache

ENV DIR_OPENCART="/var/www/html"
ENV DIR_STORAGE="/storage"
ENV DIR_CACHE="/storage/cache"
ENV DIR_DOWNLOAD="/storage/download"
ENV DIR_LOGS="/storage/logs"
ENV DIR_SESSION="/storage/session"
ENV DIR_UPLOAD="/storage/upload"
ENV DIR_IMAGE="/var/www/html/image"

# --- Install Dependencies ---
RUN apt-get update && apt-get install -y \
    unzip \
    curl \
    vim \
    libfreetype6-dev \
    libjpeg62-turbo-dev \
    libpng-dev \
    libzip-dev \
    && docker-php-ext-configure gd --with-freetype --with-jpeg \
    && docker-php-ext-install gd zip mysqli

# --- Create storage folder ---
RUN mkdir -p ${DIR_STORAGE}

# --- Copy OpenCart source (đã giải nén sẵn) ---
# Bạn có thư mục "upload" trong project
COPY upload/ ${DIR_OPENCART}/

# --- Move system/storage → /storage ---
RUN mv ${DIR_OPENCART}/system/storage/* ${DIR_STORAGE}/

# --- Copy configs & PHP settings ---
COPY configs/ ${DIR_OPENCART}/
COPY upload/php.ini ${PHP_INI_DIR}

# --- Enable Apache rewrite ---
RUN a2enmod rewrite

# --- Fix Permissions (chuẩn cho OpenCart) ---
RUN chown -R www-data:www-data ${DIR_OPENCART} ${DIR_STORAGE} \
    && chmod -R 755 ${DIR_OPENCART} \
    && chmod -R 777 ${DIR_STORAGE}

CMD ["apache2-foreground"]
