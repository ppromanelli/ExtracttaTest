# Dockerfile (no diretório ExtracttaTest.Presentation)
FROM node:18-alpine

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

EXPOSE 4200

CMD ["npm", "run", "start"]

## Etapa 1: Build da aplicação Angular
#FROM node:18 AS build
#
#WORKDIR /app
#COPY . .
#
#RUN npm install
#RUN npm run build --prod
#
## Etapa 2: Servir com NGINX
#FROM nginx:alpine
#
#COPY --from=build /app/dist/extractta-test-presentation /usr/share/nginx/html
#
#EXPOSE 80
#CMD ["nginx", "-g", "daemon off;"]
