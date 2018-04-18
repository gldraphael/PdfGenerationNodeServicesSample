# Stage 0
# Build the project
FROM microsoft/aspnetcore-build:2.0.5-2.1.4 AS build-env

# Install html-pdf
WORKDIR /app/packages
RUN apt-get -qq update \
    && apt-get --assume-yes install bzip2
RUN npm install html-pdf

# copy .csproj and restore dependencies
WORKDIR /app/src
COPY ./PdfGenerationNodeServicesSample.csproj .
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app/out

# Copy html-pdf's node_modules to the publish directory
WORKDIR /app/out
RUN cp -ra /app/packages/node_modules .

# Stage 1
# The final image
FROM microsoft/aspnetcore:2.0.6

# Install node (required for NodeServices)
ENV NODE_VERSION 6.13.0
ENV NODE_DOWNLOAD_SHA 467472d9adafd067588f2a20f9edcd7493d973fe107502c55d6fabfa0d3f91af
ENV NODE_DOWNLOAD_URL https://nodejs.org/dist/v$NODE_VERSION/node-v$NODE_VERSION-linux-x64.tar.gz

RUN curl -SL "$NODE_DOWNLOAD_URL" --output nodejs.tar.gz \
    && echo "$NODE_DOWNLOAD_SHA nodejs.tar.gz" | sha256sum -c - \
    && tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
    && rm nodejs.tar.gz \
    && ln -s /usr/local/bin/node /usr/local/bin/nodejs

# Install libfontconfig (required by PhantomJS)
RUN apt-get -qq update
RUN apt-get --assume-yes install libfontconfig

# Copy the built files over
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "PdfGenerationNodeServicesSample.dll"]
