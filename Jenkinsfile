pipeline {
    agent any

    environment {
        DOTNET_CLI_HOME = '.dotnet'
        WORKING_DIR = 'C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\Jenkins.Demo_master'
        PUBLISH_PROFILE = 'LocalIIS'
    }

    stages {
        stage('Echo') {
            steps {
                script {
                    echo 'CI/CD Start'
                    echo "Current LANG: ${env.LANG}"
                }
            }
        }

        stage('Restoring') {
            steps {
                echo 'Restoring NuGet packages'
                dir("${env.WORKING_DIR}") {
                    bat 'dotnet restore Jenkins.Demo.sln --configfile ".nuget\\nuget.config" --verbosity detailed'
                }
            }
        }

        stage('Build Web Project') {
            steps {
                echo 'Building Web Project'
                dir("${env.WORKING_DIR}") {
                    bat 'dotnet build Jenkins.Demo.Web/Jenkins.Demo.Web.csproj --configuration Release --verbosity detailed'
                }
            }
        }

        stage('Run Tests') {
            steps {
                echo 'Running Tests'
                dir("${env.WORKING_DIR}") {
                    bat 'dotnet test Jenkins.Demo.UnitTest/Jenkins.Demo.UnitTest.csproj --configuration Debug --no-build --verbosity detailed'
                }
            }
        }

        stage('Publish') {
            steps {
                echo "Publish Path: D:\\IIS\\Jenkins.Demo.Web"
                dir("${env.WORKING_DIR}") {
                    bat 'dotnet publish Jenkins.Demo.Web/Jenkins.Demo.Web.csproj /p:PublishUrl=D:\IIS\Jenkins.Demo.Web'
                }
            }
        }
    }

    post {
        success {
            echo 'Deployment successful!'
        }
        failure {
            echo 'Deployment failed.'
        }
    }
}