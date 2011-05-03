MediaManager
============

MediaManager is an application that allows users to manage their media (tv shows/movies). 
MM has a concept of 'App Helpers'. App Helpers are plugins that are able to retrieve metadata 
for certain types of media. There are currently app helpers for IMDB, Amazon, Tv.Com and others.

![Screenshot](https://github.com/paulduran/mediamanager/raw/master/docs/MediaManager.png)

Movies
------
MediaManager allows you to keep a catalog of your movies whether they be media files or physical media. 
Movie information such as cast, genre, movie summary and cover art can be fetched using one of the 
app helpers. Alternatively, the information can be entered manually. Please note that the cover image 
may be updated by dragging/dropping a new image over the old one.


Tv Shows
--------
Tv Shows may consist of multiple seasons and episodes. MM allows you to retrieve metadata for 
particular shows/seasons through a corresponding app helper.

![Season Info Dialog](https://github.com/paulduran/mediamanager/raw/master/docs/SeasonInfo.png)

Tv Episode files can be dropped onto the Season Maintenance form. This will attempt to identify the Tv Show and season/episode numbers.

![Import Dialog](https://github.com/paulduran/mediamanager/raw/master/docs/ImportEpisodes.png)

Once episodes have been imported and associated with their corresponding metadata, the MM app will
allow users to rename episodes. This is useful because it allows the episode files to be named 
consistently and optionally include the episode title and other information in the filename.

For example, Smallville-106.avi could be renamed to Smallville.S01E06.Hourglass.avi

![Rename Dialog](https://github.com/paulduran/mediamanager/raw/master/docs/EpisodeRenamer.png)



