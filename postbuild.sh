if [ ! -d "/app/OutputBins" ]; then
  mkdir "/app/OutputBins"
fi

for file in /app/build/*.dll; do
  cp -f "$file" "/app/OutputBins/"
done