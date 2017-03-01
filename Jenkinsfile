node {
    stage('Clone'){
		checkout scm
	}

	//stage('Clean'){
	//	sh('git clean -xdff')
	//}

    stage('Build'){
		msbuild()
	}

	//stage('Publish'){
	//	mono("Packager/bin/Release/Packager.exe", "Packager/bin/Release/Packager.exe")
	//	mono("Packager/bin/Release/Packager.exe", "ClickMac/bin/Release/ClickMac.exe")
	//	sh('cp -v ClickMac/bin/Release/ClickMac.exe ClickMac/bin/Release/_publish/')
	//}
    
	//stage('Test'){
	//	mono('Tests/bin/Release/Tests.exe','')
	//	//junit "TestResult.xml"
	//}

    //stage('Archive'){
	//	archive '**/bin/Release/'
	//}

	//stage('Post-Build'){
	//	step([$class: 'WarningsPublisher', canComputeNew: false, canResolveRelativePaths: false, consoleParsers: [[parserName: 'MSBuild']], defaultEncoding: '', excludePattern: '', healthy: '', includePattern: '', messagesPattern: '', unHealthy: ''])
	//}

}