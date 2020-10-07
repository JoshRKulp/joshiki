# login
az acr login --name ##ACR Name##

#  build the image
docker build -t ##ACR Name##.azurecr.io/jmeter-base:latest -f jmeterbase-docker
# push the image to the acr
docker push ##ACR Name##.azurecr.io/jmeter-base:latest

#  build the image
docker build -t ##ACR Name##.azurecr.io/jmeter-master:latest -f jmetermaster-docker
# push the image to the acr
docker push ##ACR Name##.azurecr.io/jmeter-master:latest

#  build the image
docker build -t ##ACR Name##.azurecr.io/jmeter-slave:latest -f jmeterslave-docker
# push the image to the acr
docker push ##ACR Name##.azurecr.io/jmeter-slave:latest