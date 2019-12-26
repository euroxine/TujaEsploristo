# Tuja-esplorito, tuja-Json
```
Kio estas tio apo? 
Ĉi tiu apo estas uzata por konverti dokumentojn de tuja-vortaro al dosieroj en Json.
Ĝi estas skribita en .Net Core 3.1 kaj tial kongrua kun Mac aŭ Windows.
Vi devas unue elŝuti la dosierojn el https://github.com/sstangl/tuja-vortaro
```
## Kiel uzi tio apo?
```
Unue, donu la ligilon de la dosierujo kie vi elŝutis tuja-vortaro
Due, indiku kion vi volas konverti

Por konverti ESPDIC al Json:
> ./TujaEsploristo ujo=/Users/Adamo/Desktop/tuja-vortaro-master krei=espdic

Por konverti la etimologio al Json:
> ./TujaEsploristo ujo=/Users/Sofia/Desktop/tuja-vortaro-master krei=etimologio

Por konverti la dosierojn de tujo-vortaro en UTF8
> ./TujaEsploristo ujo=/Users/Adamo/Desktop/tuja-vortaro-master krei=utf8xml

Por krei la vortorojn en aliaj lingvoj
> ./TujaEsploristo ujo=/Users/Sofia/Desktop/tuja-vortaro-master krei=vortaroj

Por krei vortaron kun difinoj kaj ekzemploj
> ./TujaEsploristo ujo=/Users/Lidia/Desktop/tuja-vortaro-master krei=difinoj
```

