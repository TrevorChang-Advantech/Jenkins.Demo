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
                    echo 'CI/CD Start'
                    echo "Current LANG: ${env.LANG}"
                    echo "Current LC_ALL: ${env.LC_ALL}"
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
                    // 切换到 UTF-8 编码，防止乱码
                    bat 'chcp 65001'
                    bat 'dotnet build Jenkins.Demo.sln --configuration Release --verbosity detailed'
                }
            }
        }

        stage('Test') {
            steps {
                script {
                    // 切换到 UTF-8 编码，防止乱码
                    bat 'chcp 65001'
                    bat 'dotnet test Jenkins.Demo.sln --logger "trx;LogFileName=unit_tests.xml" --verbosity detailed'
                }
            }
        }

        stage('Publish') {
            steps {
                script {
                    bat "mkdir ${env.PUBLISH_DIR}"
                    // 切换到 UTF-8 编码，防止乱码
                    bat 'chcp 65001'
                    bat "dotnet publish Jenkins.Demo.sln --configuration Release --output ${env.PUBLISH_DIR}"
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
