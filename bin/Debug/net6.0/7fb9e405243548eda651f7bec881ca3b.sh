function list_child_processes(){
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}

ps 4843;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 4843 > /dev/null;
done;

for child in $(list_child_processes 4955);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/mikaelandres/code/ContosoPizza/bin/Debug/net6.0/7fb9e405243548eda651f7bec881ca3b.sh;
