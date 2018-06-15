# AR_Atua

An AR app using Unity and the Mapbox SDK.

The 3D model is exported from Blender. I apply cloth animations to its hair and clothes. 

A live weather API is pulled in. I script the model's behaviours to respond to the speed and strength of the wind.

We use Mapbox to place the object on top of Mount Victoria, Wellington using geolocation. We also experiment with manual alignment to make up for the weaknesses in Mapbox's geolocation.

We paint the object with an occlusive material. Mapbox renders the city's buildings with real elevation data. We make these buildings invisible but give them the ability to obscure the 3d model. This means that when a building passes between the user and the 3D model on Mount Victoria, the 3D model disappears.

I used ARKit to render out to iOS via XCode. 

Completed in 6 days. Website and videos here: https://www.atua-ar.herokuapp.com
