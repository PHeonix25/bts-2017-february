# Build the image (called blog, version 'latest')
docker build . -t servercore-seq:latest 

# Run an instance of the image in the background, opening port 5341 as well
$container = docker run -d -t -p 5341:5341 servercore-seq:latest

# Launch the browser so that we can check our work
start 'http://localhost:5341/'

# Attach to the running container (for debug purposes)
#docker attach $container