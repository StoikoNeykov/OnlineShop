node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat 'nuget restore ./OnlineShop/OnlineShop.sln'
		bat "\"${tool 'MSBuild'}\" ./OnlineShop/OnlineShop.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
}