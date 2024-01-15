# Dockerfile for YourGoApp

FROM golang:latest AS build
WORKDIR /app
COPY ./Elympics.RandomNumber.Api/ .
RUN go build -o main .

FROM golang:latest AS final
WORKDIR /app
COPY --from=build /app/main .
EXPOSE 5001
CMD ["./main"]