#!/bin/bash

if [ "$#" -ne 1 ]; then
    echo "Illegal number of parameters"
    exit
fi

FILENAME=$1
if [ -f $FILENAME ]; then
    echo "$FILENAME exists"
fi

echo "No exit"