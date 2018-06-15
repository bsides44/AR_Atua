# AR_Atua

Building an AR app with Unity and the Mappbox SDK.

The 3D model was exported from Blender as an .fbx. I applied cloth physics to its clothing and hair in Unity so these would animate naturally in response to wind. I pulled in a live weather API and scripted the 3D model's behaviours to respond to the speed and direction of the current wind.

We used the Mapbox SDK to place the 3D model on Mount Victoria, Wellington, so when you looked at the mountain with your phone the model appeared there. We also experimented with manual alignment to compensate for the weaknesses in Mapbox's geolocation.

We painted the model with an occlusive material. Mapbox renders the city's buildings with real elevation data. We made the buildings invisible but still present. This means that when a building passes between the user and the model on the mountain while they are walking, the model disappears.

I used ARKit to publish the app to iOS via XCode.

Concept and videos here: https://www.atua-ar.herokuapp.com
