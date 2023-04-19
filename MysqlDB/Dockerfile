FROM docker.io/mysql:latest

RUN chgrp -R 0 /docker-entrypoint-initdb.d && \
    chmod -R g=u /docker-entrypoint-initdb.d

ADD MysqlDB/schema.sql /docker-entrypoint-initdb.d

EXPOSE 33060
