FROM php:8.2.11-apache

ARG DOWNLOAD_URL
ARG FOLDER

ENV DIR_OPENCART="/var/www/html/"
ENV DIR_STORAGE="/storage/"
ENV DIR_CACHE="${DIR_STORAGE}cache/"
ENV DIR_DOWNLOAD="${DIR_STORAGE}download/"
ENV DIR_LOGS="${DIR_STORAGE}logs/"
ENV DIR_SESSION="${DIR_STORAGE}session/"
ENV DIR_UPLOAD="${DIR_STORAGE}upload/"
ENV DIR_IMAGE="${DIR_OPENCART}image/"

# Basic packages
RUN apt-get clean && apt-get update && apt-get install -y unzip vim

# PHP extensions
RUN apt-get install -y \
    libfreetype6-dev \
    libjpeg62-turbo-dev \
    libpng-dev \
    libzip-dev \
    && docker-php-ext-configure gd --with-freetype --with-jpeg \
    && docker-php-ext-install -j"$(nproc)" gd \
    && docker-php-ext-install zip \
    && docker-php-ext-enable zip \
    && docker-php-ext-enable mysqli

# Storage folders
RUN mkdir /storage && mkdir /opencart

# Download OpenCart (latest release or custom URL)
RUN if [ -z "$DOWNLOAD_URL" ]; then \
        curl -Lo /tmp/opencart.zip $(sh -c 'curl -s https://api.github.com/repos/opencart/opencart/releases/latest | grep "browser_download_url" | cut -d : -f 2,3 | tr -d \"'); \
    else \
        curl -Lo /tmp/opencart.zip ${DOWNLOAD_URL}; \
    fi

# Extract OpenCart
RUN unzip /tmp/opencart.zip -d /tmp/opencart

RUN mv /tmp/opencart/$(if [ -n "$FOLDER" ]; then echo $FOLDER; else unzip -l /tmp/opencart.zip | awk '{print $4}' | grep -E 'opencart-[a-z0-9.]+/upload/$'; fi)* ${DIR_OPENCART}

# Clean
RUN rm -rf /tmp/opencart.zip /tmp/opencart ${DIR_OPENCART}install

# Move storage
RUN mv ${DIR_OPENCART}system/storage/* /storage

# Copy configs + php.ini
COPY configs ${DIR_OPENCART}
COPY upload/php.ini ${PHP_INI_DIR}

# Enable rewrite
RUN a2enmod rewrite

# PHP extensions
RUN apt-get install -y \
    libfreetype6-dev \
    libjpeg62-turbo-dev \
    libpng-dev \
    libzip-dev \
    && docker-php-ext-configure gd --with-freetype --with-jpeg \
    && docker-php-ext-install -j"$(nproc)" gd zip mysqli

CMD ["apache2-foreground"]
