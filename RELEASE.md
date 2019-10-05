# Releasing

This document describes the general process for releasing any of the 3Dtbd assets.

## Pacakge Manager Release

We use [Jeff Campbell's Unity Package Tools](https://github.com/jeffcampbellmakesgames/unity-package-tools) to help with building releases. Install these tools from the release package on GitHub (we don't install via package manager as we don't want them to be installed as a dependency of our projects).

[Full usage instructions](https://github.com/jeffcampbellmakesgames/unity-package-tools/blob/master/usage.md) are available, the below is a summary for convenience. It describes the release process for all 3Dtbd assets.

  0. Ensure all changes you want to release are in the Master branch of your repo and have been thoroughly tested. Push all these changes upstream then tag the branch with:

```bash
git tag -a v$VERSION -m "v$VERSION"
```

  1. In the Unity Editor open `PackageManifestConfig` which can be found in the project root
  2. Update the Package Version Number, it should be the same as the environment variable `VERSION` (see below)
  3. Review all other settings in particular ensure that the `Package Name` is the same as the environment variable `PACKAGE` (see below)
  4. Click Export Package in the inspector for `PackageManifestConfig`
  5. Setup your enviornment by setting the following environment variables

 ```bash
  PACKAGE="[PACKAGE NAME]"
  VERSION="[x.y.z]"
```
  5. In bash, `pushd` to the export directory and run the following commands:

  ```bash
  git init
  git remote add origin git@github.com:3dtbd/$PACKAGE.git
  git checkout --orphan release/v$VERSION
  git add .
  git commit -m "Release v$VERSION"
  git push origin release/v$VERSION
  ```
  6. `popd`
