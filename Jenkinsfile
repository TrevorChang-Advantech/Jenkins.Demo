pipeline {
    agent any

    environment {
        DOTNET_CLI_HOME = '.dotnet'
        PUBLISH_DIR = 'D:\\IIS\\Jenkins.Demo.Web'
        JAVA_TOOL_OPTIONS = '-Dfile.encoding=UTF-8'
        LANG = 'en_US.UTF-8'
        LC_ALL = 'en_US.UTF-8'
    }

    stages {
        stage('Echo') {
            steps {
                script {
                    echo 'CI/ CD Start'
                }
            }
        }

        stage('Clean NuGet Cache') {
            steps {
                echo 'Cleaning NuGet Cache'
                bat 'dotnet nuget locals all --clear'
            }
        }

        stage('Restoring') {
            steps {
                echo 'Restoring NuGet packages'
                bat 'dotnet restore Jenkins.Demo.sln --verbosity detailed'
            }
        }

        stage('Build') {
            steps {
                script {
                    bat 'dotnet build --configuration Release --verbosity detailed'
                }
            }
        }

        stage('Test') {
            steps {
                script {
                    bat 'dotnet test --logger "trx;LogFileName=unit_tests.xml"'
                }
            }
        }

        stage('Publish') {
            steps {
                script {
                    bat "dotnet publish --configuration Release --output ${env.PUBLISH_DIR}"
                }
            }
        }
    }

    post {
        always {
            cleanWs()
        }
        success {
            echo 'Deployment successful!'
        }
        failure {
            echo 'Deployment failed.'
        }
    }
}