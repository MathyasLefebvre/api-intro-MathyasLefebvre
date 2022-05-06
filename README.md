# Introduction au développement d'API et au côté DevOps/Infrastructure

Votre mission principale #05 consiste à répondre à quelques questions sur les API/DevOps/Invous et à concevoir une API simple pour familiariser avec différents concepts. En outre, vous aurez à :
1. Répondre aux questions dans le fichier [quiz.md](quiz.md)
2. Concevoir un API respectant les fonctionnalités demandées
3. Faire un test de performance JMeter (fichier .jmx à mettre dans votre dépôt Git)

L'utilisation de Git continue à être importante, mais également votre capacité à faire de bonnes recherches et à poser de bonnes questions. Ce travail simule que vous avez une tâche précise à effectuer et que vous aurez à communiquer avec votre développeur senior pour confirmer ce qui bloque votre travail et ce qui n'est pas clair dans le but d'améliorer votre autonomie.

Toutefois, vous ne devriez pas poser de questions `niaiseuses`, `non-recherchées` ou `non-réfléchies` à votre senior. Vous ne devriez pas non plus poser des questions continuellement et déranger votre senior plusieurs fois par jour, vous devriez accumuler plusieurs questions et les poser dans le but de vous débloquer pour pouvoir continuer et re-continuer à accumuler vos prochaines questions. 

# Quiz

Les questions se trouvent dans le fichier [quiz.md](quiz.md).

# API

## Vue d'ensemble

Vous allez concevoir un API qui va utiliser un autre API, une base de données Postgres, un magasin de structure de données Redis (pour le défi) et un fichier sur le système de fichier. Le but de l'API est de vous faire toucher à plusieurs technologies différentes et à gérer un problème de concurrence précis dans un contexte API.

__Attention__: Un fichier Docker de base est fourni pour ceux désirant utiliser Docker. Toutefois, j'assume que vous avez tous accès à une base de données Postgres à cause de vos autres cours. __Si ce n'est pas le cas, vous devez me contacter immédiatement pour me le dire, si vous attendez à la dernière minute pour me le dire, vous serez responsable du résultat obtenu__. 

## Infrastructure

Vous avez la possibilité de procéder de la manière que vous désirez (installation locale, une machine virtuelle, une VM au Cégep ou Docker). Cependant, vous devez avoir les éléments suivants :
* Base de données Postgres
* Magasin de structure de données Redis (pour le défi)

## Validation

Toutes les entrées (e.g. le JSON) doivent être validées et vous devez retourner le code HTTP approprié et le message d'erreur comme il faut (e.g. que devrait contenir la réponse "erreur" pour une API? etc.).

Des détails sont fournis pour chaque route pous vous guider.

## Code

Vous devez minimalement utiliser une structure dans le code utilisant des `Services`, des `Models` (privé/publique), des `Mappers`, etc. et une séparation avec un projet Core et un projet API. Si vous voulez aller plus loin, essayer de séparer en plus de que seulement 2 projets (un projet pour le Core, un projet pour les accès à la base de données, un projet pour l'API, etc.).

Pour l'accès à la base de données, vous pouvez utiliser le EntityFramework ou LINQ to SQL.

## Logging

Vous devez utiliser Serilog et faire de bons logs avec de bonnes informations dans votre code.

## Endpoints / Routes

Pour votre API, vous allez devoir faire les endpoints/routes suivantes :

### `POST /api/v1/orders`

Cette route prendra en paramètre le JSON suivant pour insérer les données dans les tables associées de la base de données Postgres (le script SQL est fourni dans les fichiers initials) :

```json
{
	"customer": {
		"firstname": "Jordan",
		"lastname": "Rioux",
		"email": "jordan@rioux.com"
	},
	"order": {
		"country": "Canada",
		"street": "123 fake street",
		"city": "Sorel-Tracy",
		"zipCode": "J3R1L1",
		"total": 420.69,
		"items": [{
			"price": 20.69,
			"description": "C# In Depth (book)",
			"quantity": 1
		}, {
			"price": 100,
			"description": "Clean Code (book)",
			"quantity": 4
		}]
	}
}
```
Toutes les entrées sont obligatoires. Vous devez donc valider que tous les champs sont fournis et qu'ils respectent leur type (vide ou non, chiffres, etc.).

Votre route devra écrire dans le fichier `order_stats.json` pour indiquer les informations sur la commande venant d'être créer (nombre d'items, etc.). Ce fichier permettra de savoir le nombre total de commandes créé, le nombre total d'items dans ces commandes et la géolocalisation des clients (Canada ou non). Les informations seront sauvegardés en JSON :

```json
{
	"country": {
		"canada": 22,
		"other": 2
	},
	"stats": {
		"orders": 23,
		"orderItems": 122
	}
}
```

Attention à la concurrence ici! Vous allez devoir lire les données du fichier, les incrémenter et re-sauvegarder les données. Cependant, dans un contexte API, cette route peut être appelé par plusieurs utilisateurs en même temps.

### `GET /api/v1/stats`

Cette route n'a aucune entrée et retourne les statistiques se trouvant dans le fichier `order_stats.json` dans le format JSON suivant :

```json
{
	"ordersCount": 23,
	"orderItemsCount": 122,
	"orderedFromCanadaCount": 22,
	"orderedFromOtherCountriesCount": 2,
}
```

Ici, le format du JSON du fichier n'est pas le même que celui retourné. Il est donc important d'utiliser une entité qui sera exposé publiquement et une entité privée qui représente le "format à l'interne" et vous aurez un Mapper pour convertir de un vers l'autre et vice-versa.

### `GET /api/v1/weather` (défi)

Cette route appellera l'API de OpenWeather (https://openweathermap.org/current) pour obtenir la météo d'une ville. On lui passera le JSON suivant :

```json
{
	"city": "Sorel",
	"mode": "json",
	"units": "metric",
	"lang": "fr"
}
```

Vous devez valider que les entrées JSON :
* Le `city` est obligatoire. 
* Le `mode`, le `units` et le `lang` sont optionnels et doivent correspondre aux données attendues par l'API OpenWeather.

Pour cette route, vous devez utiliser Redis pour mettre en cache les données de l'API. La cache sera de 15 secondes (pour les besoins du TP). La logique est la suivante :
* Si vous avez les données pour la ville en cache, vous récupérer ces données de Redis et les retourner.
* Si les données ne sont pas en cache, vous allez appelé l'API pour récupérer les données, les sauvegarder dans Redis et les retourner.

# Test de performance JMeter

Pour tester le côté concurrence de votre API, vous allez devoir écrire un test utilisant JMeter va appeler `/api/v1/orders/` plusieurs fois pour insérer les données. 

Ensuite, vous allez pouvoir vérifier que `/api/v1/stats/` retourne les bonnes informations (e.g. que la concurrence est bien gérer).

Si vous faites le défi, vous pouvez également vous amuser à faire un test pour `/api/v1/weather/` pour tester votre cache avec Redis.

# Liens utiles

* Introduction aux API avec .Net (https://dotnet.microsoft.com/en-us/apps/aspnet/apis) 
* Restful API design (https://www.vinaysahni.com/best-practices-for-a-pragmatic-restful-api)
* Mapper (https://www.simplilearn.com/tutorials/asp-dot-net-tutorial/automapper-in-c-sharp)
* API de OpenWeather (https://openweathermap.org/current)
* Entity Framework avec Postgres (https://www.endpointdev.com/blog/2021/07/dotnet-5-web-api/ et https://www.tutlinks.com/minimal-web-api-with-crud-on-postgresql-dotnet-6/)
* JMeter performance test (https://www.guru99.com/jmeter-performance-testing.html)
* Model Validation in .Net (https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api)
* Exemple complet avec logging (https://github.com/jasontaylordev/CleanArchitecture/blob/413fb3a68a0467359967789e347507d7e84c48d4/src/Application/Common/Behaviours/UnhandledExceptionBehaviour.cs#L25)
* Faites des recherches sur "Clean Architecture .Net" pour trouver des exemples de code pour mieux vous guider (https://github.com/cristofima/StoreCleanArchitecture-NET/blob/v2.0.0/src/Store.ApplicationCore/DependencyInjection.cs)
