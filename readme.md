This tool converts the output of `GET /trustlist` from the DCCG into a directory (or directory per country) of files in either PEM or DER formats.

You can change the directory or export formats by changing the flags in `dgcg2pem/Program.cs`: `EXPORT_PEM`, `EXPORT_DER` and `EXPORT_PER_COUNTRY`.

# Building & Publishing

To use this tool first download `.Net 7.0.0 SDK` for your platform from https://dotnet.microsoft.com/en-us/download and install it. 

Then you can build this project by doing:

	dotnet build

You can publish by doing this:

	dotnet publish -o dist

Where `dist` is the folder you want to publish to.

# Running

Then you can run it by moving to the output directory:

	cd dist

and running:

	./dgcg2pem your-trust-list.json ./path/to/directory/where/files/will/be/saved

The project includes the trustlist from acceptance dated 2022-11-28. This is copied into the `dist` directory by the `publish` command.

To use the provided trustlist:

	./dgcg2pem acc.json ./output

Windows user? then you don't need to include the `./` and can run it like this:

	dgcg2pem acc.json ./path/to/directory/where/files/will/be/saved
