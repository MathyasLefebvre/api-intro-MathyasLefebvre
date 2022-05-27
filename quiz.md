# Quiz

Répondre aux questions directement dans ce fichier.




# Infrastructure

### 1. Qu'est-ce que le `vertical scaling`?
    Le vertical scaling consiste à améliorer les machines d'une infrastructures en augmentant la puissance de calcul de celles-ci.
    Toutefois, la machine n'est pas modifier donc il n'y a pas besoin de refaire le code pour que celui-ci marche sur cette machine.


### 2. Qu'est-ce que le `horizontal scaling`?
    Contrairement au vertical scaling, le "horizontal scaling" consiste à ajouter le nombres de machines toute en améliorant pas
    les machines déja en place.

### 3. Qu'est-ce que signifie `DevOps`? 
    Le DevOps est un mouvement qui encourage la collaboration entre les équipes de développement et d'exploitation en ce qui
    concerne le domaine de l'informatique. En effet, celui-ci a pour but d'améliorer la qualité du travail et des relations.
    Le DevOps prône qu'en unissant ces deux équipes, il y plus de satisfaction du client et il sera possible de livrer du nouveau 
    code sur demande et maintenir la disponibilité des services.

### 4. Qu'est-ce que Redis? À quoi cela sert-il?
    Redis est un magasin de structure de données clé/valeur en mémoire open source rapide, qui permet d'enregistrés
    de l'information dans des tableaux hachés. On peut stocker différent type de structure d'information dans ces tableaux.
    Par exemple, des strings,des listes et autres. Redis signifie Remote Dictionary Server. Avec ses structures de données en 
    mémoires polyvalentes, Redis peut servir un large éventail d'applications. Par exemple, la mise en cache, la gestion des sessions 
    et les classements.

### 5. Quel est l'inconvénient d'utiliser la persistence par défaut des sessions dans une application Web?
    Je dirais que l'inconvenient d'utiliser des sessions afin de faire la gestion des données est quel se perd qu'on ferme 
    la page Web ou elle se relance après un certain temps.

### 6. Comment pourrions-nous éviter ce problème? Expliquer un exemple d'architecture que nous pourrions mettre en place.
    Il foudrait éviter de stocker des données dans la session comme on le fait souvent. On pourrait faire un projet basé sur des cookies

### 7. Pourquoi est-il important d'avoir de bons logs dans notre application?
    Les logs sont très importantes pour une application puisqu'elles nous aident , et ce, pour plusieurs raisons dans différentes branches. Tout d'abord, dans la
    phase de développement de l'application, ça l'aide au débug et ça permet de comprendre le fonctionnement de l'application. Dans la phase de l'intégration, les
    logs nous aident à voir si il y a des anomalies dans le comportement du programme. Finalement, dans la phase d'exploitation, les logs nous permettent de voir des
    problèmes de prod.

### 8. À quoi servent les outils comme Seq, Elastic Search, Splunk, etc.? Quels sont les avantages?
    Toutes ses outils sont qui permettent la collecte ou l'analyse de données. Ses outils permettent d'aller chercher des données
    rapidement, en plus de les structurés. 



# API

### 1. Qu'est-ce que nous voulons dire quand on parle d'un CRUD?
    Quand on parle de CRUD, cela désigne les quatres opérations de base pour la persistance
    des données. Il s'agit du Create, du Read, de l'Update et du Delete.

### 2. Donnez-moi les exemples de routes/endpoints correspondant à un CRUD pour des `users` (e.g. donner les routes et les méthodes HTTP) :
    Create: POST /users
    Read: GET /users
    Update: PUT /update/{id}
    Delete: DELETE /users/{id}
    
### 3. Pourquoi est-il bon d'utiliser un système de gestion des versions pour un API (e.g. v1/v2/...)?
    Il est important d'avoir plusieurs versions de sont API, la rison la plus courante est pour respecter nos clients existants.
    En effet, même si on améliore notre API, l'application de nos clients nécessite peut-être absolument la version de l'API avant
    la mise à jour de celle-ci. Donc, en faisant des versions, il n'y a plus de problème. 

### 4. À quoi servent les outils comme JMeter?
    JMeter est un logiciel développé par Apache qui a pour but de tester le comportement
    fonctionnel et mesurer la performances d'une application.

### 5. Pourquoi est-il important de tester son site ou son API avec un outil comme JMeter?
    Il est important de faire des tests de performance sur son application pour plusieurs
    raisons. Premièrement, permet d'avoir certaines informations sur l'application, par exemple, 
    sa vitesse, sa stabilité ou son évolutivité. Deuxièmement, encore plus important, cela permet de découvrir ce 
    qui doit être à améliorer avant la mise en marché du produit.

### 6. Qu'est-ce qu'une migration (base de données)?
    Dans le domaine informatique, la migration de base de données consiste à déplacer les données que nous avons vers
    une autre base de données. Par exemple, je veux mettre mon appliaction sur le cloud, alors je migre les données de
    celle-ci vers le cloud. Il s'agit d'une migration.

### 7. Qu'est-ce que Swagger?
    Swagger est une application open source qui regroupe un ensemble d'outils pour écrire de API. En effet, Swagger 
    simplifie le processus de création d'un API en spécifiant les normes et en fournissant les matériels nécessaire 
    à la création d'une bonne API.


