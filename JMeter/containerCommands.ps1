##Need to create new clusters for each enviroment
.\CreateTestRig.ps1 -tenant jmeter -subdns abbnftjk -AksResourceGroup nft-aks-eastus -AksClusterName nftaks2

.\CreateTestRig.ps1 -tenant jmeter -subdns abbnftah -AksResourceGroup nft-aks-anaheim -AksClusterName nftaksanaheim

.\CreateTestRig.ps1 -tenant jmeter -subdns abbnftah2 -AksResourceGroup nft-aks-anaheim2 -AksClusterName nftaksanaheim2

##Need to remove all parts of a cluster
.\DeleteCluster.ps1 -tenant jmeter -AksResourceGroup nft-aks-eastus -AksClusterName nftaks2

##After you create the cluster it needs to be scalled to handel more nodes
az aks scale --name nftaksjm --resource-group NFT-JMeter-poc --node-count 6

az aks scale --name nftaksanaheim --resource-group nft-aks-anaheim --node-count 15

##Use this to look at the Kuberneties Dashboard
az aks browse --name nftaks2 --resource-group nft-aks-eastus


##Use this to delete if the create cluster fails
kubectl -n jmeter delete -f jmeter_master_deploy.yaml
kubectl -n jmeter delete -f jmeter_slaves_deploy.yaml


## Use this to connect your kubectl to your azure resource group
az aks get-credentials --resource-group NFT-Jmeter-poc --name nftaksjm

az aks get-credentials --resource-group nft-aks-anaheim --name NFT-Anaheim-Aks-2

az aks get-credentials --resource-group nft-aks-anaheim --name nftaskanaheim

##Run this before every test to setup the machines you need to run
.\jmeter_cluster_create.ps1 -tenant jmeter -scaleslave 3

##This will run the test on the cluster you just created
.\run_test.ps1 -tenant jmeter -testname c:\abb\InstanceTest.jmx -reportfolder report11

##Use this to look at the Kuberneties Dashboard
az aks browse --name nftaksjm --resource-group NFT-Jmeter-poc

az aks browse --name nftaksanaheim --resource-group nft-aks-anaheim

az aks browse --resource-group nft-aks-anaheim --name NFT-Anaheim-Aks-3


##run in cloud shell




az aks browse --name nftaksjm --resource-group NFT-JMeter-poc
az aks scale --name nftaksjm --resource-group NFT-JMeter-poc --node-count 10

az aks get-credentials --resource-group NFT-JMeter-poc --name nftaksjm

kubectl -n jmeter get pods --selector=jmeter_mode=master --no-headers=true --output=name

az aks get-credentials --resource-group nft-aks-anaheim --name NFT-1909-AKS
kubectl create namespace jmeter
kubectl create secret docker-registry abbhub --namespace jmeter --docker-server=abbability.azurecr.io --docker-username=abbability --docker-password=+zoc=m/j+wip2ikYoAen/I7nr0O+WbVS
az aks browse --resource-group nft-aks-anaheim --name NFT-1909-AKS

az aks get-credentials --resource-group nft-aks-anaheim --name NFT-Anaheim-Aks-2
kubectl create namespace jmeter
kubectl create secret docker-registry abbhub --namespace jmeter --docker-server=abbability.azurecr.io --docker-username=abbability --docker-password=+zoc=m/j+wip2ikYoAen/I7nr0O+WbVS

kubectl create clusterrolebinding kubernetes-dashboard --clusterrole=cluster-admin --serviceaccount=kube-system:kubernetes-dashboard

NFT-Anaheim-Aks-2