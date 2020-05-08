FROM openjdk:7
COPY . /usr/src/myapp
WORKDIR /usr/src/myapp/source_code
RUN javac MainGame.java Main.java
CMD ["java", "Main"]
