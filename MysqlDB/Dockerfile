#FROM registry.redhat.io/rhel9/mysql-80
FROM docker.io/mysql:debian

ADD MysqlDB/schema.sql /docker-entrypoint-initdb.d

#RUN chgrp -R 0 /docker-entrypoint-initdb.d && \
#    chmod -R g=u /docker-entrypoint-initdb.d

EXPOSE 33060
