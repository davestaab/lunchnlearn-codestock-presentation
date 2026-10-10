# UI on http://localhost:18888; OTLP on 4317 (gRPC) and 4318 (HTTP).
# The login token is printed in the container logs: docker logs aspire-dashboard
docker run --rm -d -p 18888:18888 -p 4317:18889 -p 4318:18890 \
  --name aspire-dashboard mcr.microsoft.com/dotnet/aspire-dashboard:latest
