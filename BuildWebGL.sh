#!/bin/bash
echo "Attempting to build WebGL"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -buildWebGLPlayer "BUILD" \
  -quit
rc0=$?
echo "Build logs (WebGL)"
cat $(pwd)/unity.log
exit $rc0
