pipeline {
    agent any

    environment {
        DOTNET_CLI_HOME = '.dotnet'
        PUBLISH_DIR = 'D:\\IIS\\Jenkins.Demo.Web'
    }

    stages {
        stage('Restore') {
            steps {
                script {
                    bat 'dotnet restore'
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