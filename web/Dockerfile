FROM node AS builder
LABEL maintainer="jonifen <gamebrowser@dev.jonifen.co.uk>"

WORKDIR /app
COPY . /app
RUN npm i
RUN npm run build


FROM nginx:alpine
LABEL maintainer="jonifen <gamebrowser@dev.jonifen.co.uk>"
COPY --from=builder /app/dist /usr/share/nginx/html
