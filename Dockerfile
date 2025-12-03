FROM php:8.2.11-apache

ENV DIR_OPENCART="/var/www/html"
ENV DIR_STORAGE="/storage"

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

# --- Copy OpenCart source (đã giải nén sẵn) ---
COPY upload/ ${DIR_OPENCART}/

# --- Prepare storage volume ---
RUN mkdir -p ${DIR_STORAGE} \
    && cp -r ${DIR_OPENCART}/system/storage/* ${DIR_STORAGE}/ \
    && rm -rf ${DIR_OPENCART}/system/storage \
    && ln -s ${DIR_STORAGE} ${DIR_OPENCART}/system/storage

# --- Copy configs & php.ini ---
COPY configs/ ${DIR_OPENCART}/
COPY upload/php.ini ${PHP_INI_DIR}

# --- Enable Apache rewrite ---
RUN a2enmod rewrite

# --- Permissions ---
RUN chown -R www-data:www-data ${DIR_OPENCART} ${DIR_STORAGE} \
    && chmod -R 755 ${DIR_OPENCART} \
    && chmod -R 777 ${DIR_STORAGE}

CMD ["apache2-foreground"]
