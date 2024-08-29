pipeline {
    agent any

    environment {
        DOTNET_CLI_HOME = '.dotnet'
        WORKING_DIR = 'C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\Jenkins.Demo_master'
        PUBLISH_PROFILE = 'LocalIIS'
        JAVA_TOOL_OPTIONS = '-Dfile.encoding=UTF-8'
        LANG = 'en_US.UTF-8'
        LC_ALL = 'en_US.UTF-8'
    }

    stages {
        stage('Echo') {
            steps {
                script {
                    echo 'CI/CD Start'
                    echo "Current LANG: ${env.LANG}"
                    echo "Current LC_ALL: ${env.LC_ALL}"
                }
            }
        }

        stage('Clean Publish Directory') {
            steps {
                script {
                    bat 'rmdir /S /Q null'
                    bat "rmdir /S /Q ${env.PUBLISH_DIR}"
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
                    bat 'dotnet test Jenkins.Demo.Tests/Jenkins.Demo.Tests.csproj --configuration Release --no-build --verbosity detailed'
                }
            }
        }

        stage('Publish') {
            steps {
                script {
                    bat "mkdir ${env.PUBLISH_DIR}"
                    dir("${env.WORKING_DIR}") {
                        // 切换到 UTF-8 编码，防止乱码
                        bat 'chcp 65001'
                        bat "dotnet publish Jenkins.Demo.Web/Jenkins.Demo.Web.csproj /p:PublishProfile=${env.PUBLISH_PROFILE}.pubxml"
                    }
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