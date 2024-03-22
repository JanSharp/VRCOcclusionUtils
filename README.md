
# Occlusion Utils

Little utilities to help with occlusion, specifically occlusion portals.

# Installing

Head to my [VCC Listing](https://jansharp.github.io/vrc/vcclisting.xhtml) and follow the instructions there.

# Occlusion Portals

A few things about `Occlusion Portals` components:

- They do not need any mesh renderers
- They do not need either of the static occluder nor static occludee flags set
- They do not need colliders (see next section)

So basically they act completely independently from anything else on the object.

In terms of functionality they behave just like a box mesh with the dimensions of the portal, with the added feature of being able to toggle it on and off at runtime. This feature appears to be truly additive without negatively affecting its effectiveness, neither increasing the occlusion data size by any noticeable amount.

# Colliders

If you ever thought that occlusion took colliders into consideration, now you'll know that this is in fact not the case. It's just Mesh Renderers and Occlusion Portals.

# Utils

## Occlusion Portals Toggle Area

Open and close an array of `Occlusion Portal`s within an area. When in the area, they are open, when outside, they are closed.

The area is defined by 1 or more trigger colliders of any kind on the object with the `Occlusion Portals Toggle Area` script.

Upon entering play mode or publishing, all colliders on the same object as the area script are automatically set to be trigger colliders.
