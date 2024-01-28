#!/bin/bash

# Start the API
dotnet Calculus.Api.dll &

# Start the UI
serve ./ui -p 4200 &

# trap ctrl-c and call ctrl_c() to be able to interrupt the execution
trap ctrl_c INT
function ctrl_c() {
        echo "** Trapped CTRL-C"
}
for i in `seq 1 5`; do
    sleep 1
done

# Wait for any process to exit
wait -n

# Exit with status of process that exited first
exit $?
