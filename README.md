# TunifyPlatform

## Introduction

**Tunify** is a music streaming app where users can explore songs, create playlists, and discover artists and albums. It offers various subscription plans to meet different user needs.

## ERD Diagram

Below is the Entity-Relationship Diagram (ERD) for Tunify:

![Tunify ERD](TunifyPlatform/Tunify.png)

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

