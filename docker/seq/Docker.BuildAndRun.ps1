# Build the image 
docker build . -t servercore-seq

# Run an instance of the image in the background, opening port 5341 as well
$hostport = 5341
$container = docker run -d -t -p 5341:$hostport servercore-seq
Write-Host "Docker container started:" $container

# Find the IP of the running container
$ip = docker inspect --format="{{.NetworkSettings.Networks.nat.IPAddress}}" $container
Write-Host "Docker container IP:" $ip

# Launch the browser so that we can check our work
$seq_url = 'http://'+ $ip + ':' + $hostport + '/'
start $seq_url
Write-Host "Browser launched, pointing at" $seq_url

# Attach to the running container (for debug purposes)
#docker attach $container