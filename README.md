# SongDownloader

docker build -t song-downloader -f Dockerfile .

docker run -d -p 5000:80 --rm song-downloader --name song-downloader song-downloader