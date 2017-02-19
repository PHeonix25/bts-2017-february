FROM sebp/elk:es241_l240_k461

# updating filters
ADD ./configs/03-redis.conf /etc/logstash/conf.d/03-redis.conf
ADD ./configs/04-redis-filter.conf /etc/logstash/conf.d/04-redis-filter.conf

# modifing output
ADD ./configs/30-output.conf /etc/logstash/conf.d/30-output.conf

CMD [ "/usr/local/bin/start.sh" ]