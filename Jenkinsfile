pipeline {
    agent any

    environment {
        DOTNET_CLI_HOME = '.dotnet'
        PUBLISH_DIR = 'D:\\IIS\\Jenkins.Demo.Web'
    }

    stages {
        stage('Echo') {
            steps {
                script {
                    echo 'CI/ CD Start'
                }
            }
        }

        stage('Restore Web') {
            steps {
                script {
                    echo 'Restoring NuGet packages for Web project...'
                    bat 'dotnet restore Jenkins.Demo.Web/Jenkins.Demo.Web.csproj'
                }
            }
        }

        stage('Restore Unit Tests') {
            steps {
                script {
                    echo 'Restoring NuGet packages for Unit Test project...'
                    bat 'dotnet restore Jenkins.Demo.UnitTest/Jenkins.Demo.UnitTest.csproj'
                }
            }
        }

        stage('Build') {
            steps {
                script {
                    bat 'dotnet build --configuration Release'
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