# WindowWatcher
Monitors the topmost window to catch annoying programs that try to pop up above everything.

## Features
* Shows PID and title of the topmost window
* Keeps track of previous windows
* Export data to text, CSV, or XML files
* Monitoring can be temporarily suspended and resumed at will

## Problems/To-Do
* UX is crap
* Doesn't show command line
* Settings aren't saved (window size, state, and position; column order and sizes)
* Title is shown twice, obtained using two different methods, and are often identical (but not always)
* Can't kill other processes from within the program
* Windows from the same process with a different title are counted as different windows (see your browsing history!); this was by design but may be more annoying than useful
