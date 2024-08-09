# TunifyPlatform

## Introduction

**Tunify** is a music streaming app where users can explore songs, create playlists, and discover artists and albums. It offers various subscription plans to meet different user needs.

## ERD Diagram

Below is the Entity-Relationship Diagram (ERD) for Tunify:

![Tunify ERD](TunifyPlatform/Tunify.png)

## Architecture Overview

### Controllers

The **TunifyPlatform** uses controllers to handle incoming HTTP requests and send responses. Each controller corresponds to a particular entity in the application:

- **UsersController**: Manages user-related actions like fetching, creating, updating, and deleting users.
- **ArtistsController**: Handles artist-related requests, including getting artist details and managing artist data.
- **PlaylistsController**: Deals with operations on playlists such as creation, modification, and retrieval.
- **SongsController**: Manages song-related functionalities, including fetching songs and updating song information.

### Repositories

Repositories are used to abstract data access and provide a clean API for data operations. The following repositories are defined:

- **IUser**: Interface for user data operations.
- **IArtists**: Interface for artist-related data operations.
- **IPlayList**: Interface for playlist data operations.
- **ISong**: Interface for song data operations.

### Services

Services contain the business logic of the application and interact with the repositories to perform data operations:

- **UserServices**: Implements `IUser` and provides methods to manage user data.
- **ArtistsServices**: Implements `IArtists` to handle artist data management.
- **PlaylistsServices**: Implements `IPlayList` for playlist-related business logic.
- **SongServices**: Implements `ISong` to handle song data and logic.


## Entities Overview

### Users
- **UserId**: Unique user ID
- **UserName**: Name of the user
- **Email**: User's email
- **Join_Date**: Join date
- **Subscription_ID**: Link to subscription

### Subscriptions
- **Subscription_ID**: Unique ID
- **Subscription_Type**: Type (e.g., Free, Premium)
- **Price**: Cost

### Artists
- **Artist_ID**: Unique ID
- **Name**: Artist's name
- **Bio**: Artist's biography

### Albums
- **Album_ID**: Unique ID
- **Album_Name**: Album name
- **Release_Date**: Release date
- **Artist_ID**: Link to artist

### Songs
- **Song_ID**: Unique ID
- **Title**: Song title
- **Artist_ID**: Link to artist
- **Album_ID**: Link to album
- **Duration**: Song length
- **Genre**: Genre

### Playlists
- **Playlist_ID**: Unique ID
- **User_ID**: Link to user
- **Playlist_Name**: Playlist name
- **Created_Date**: Creation date

### PlaylistSongs
- **PlaylistSong_ID**: Unique ID
- **Playlist_ID**: Link to playlist
- **Song_ID**: Link to song

## Relationships

- **Users** have subscriptions and create playlists.
- **Artists** create albums, which contain songs.
- **Songs** belong to albums and can be part of multiple playlists.

