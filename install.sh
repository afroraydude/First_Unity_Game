#! /bin/sh
echo 'Downloading Unity 5.3.1 pkg'
curl -o Unity-5.3.1f1.pkg http://netstorage.unity3d.com/unity/cc9cbbcc37b4/MacEditorInstaller/Unity-5.3.1f1.pkg
echo 'Installing'
sudo installer -dumplog -package Unity-5.3.1f1.pkg -target /
