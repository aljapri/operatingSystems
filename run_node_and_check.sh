#!/bin/bash

echo "==== Checking Network Connection to W3Schools ===="

# Ping W3Schools
if ping -c 4 www.w3schools.com > /dev/null; then
  echo "✅ Connection to W3Schools is successful."
else
  echo "❌ Could not connect to W3Schools."
fi


echo
echo "==== Printing Windows Command to Check and Repair Disk ===="

# Print the Windows command for checking and repairing disk
echo "❗ To check and repair your disk on Windows, use the following command in Command Prompt:"
echo "chkdsk C: /f /r"

echo
echo "==== Starting Node.js Project ===="

# Navigate to your Node.js project directory
cd /home/kali/Desktop/JavaScriptProjects/shafa/backend/src || {
  echo "❌ Failed to navigate to the project directory."
  exit 1
}

# Run your Node.js application using npm
npm run dev || {
  echo "❌ Failed to run the Node.js project."
  exit 1
}



echo
echo "==== Script Complete ===="

