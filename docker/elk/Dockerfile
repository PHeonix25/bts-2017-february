FROM sebp/elk

# filters
ADD ./configs/03-redis.conf /etc/logstash/conf.d/03-redis.conf
ADD ./configs/04-redis-filter.conf /etc/logstash/conf.d/04-redis-filter.conf

CMD [ "/usr/local/bin/start.sh" ]