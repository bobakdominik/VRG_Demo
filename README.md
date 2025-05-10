# VR Group Demo App
Demo application for VR Group

## Height Map Application
This application loads a height map data and displays it in a 2D view. It allows the user to interact with the map and create circles in the map area.

### Running the application
#### Displaying the map
- After starting the application an empty window will be displayed.
- In top left corner there is a button to load a height map file.
- Clicking on it will open a file dialog where you can select a height map file.
- After loading the file, the map will be displayed in the main window.
- On bottom left corner there is a text box, where user can see map coordinates and height based on cursor location on the map (If cursor is outside of the map, text box will display "?" symbol for each value).

#### Creating circles
Note: Creating circle is only possible when the map is loaded.
1. To create a circle, click on the "Add Circle" button in top left corner.
2. Cursor will change to a crosshair. "Cancel" button will appear.
    1. First click on the map will set the center point for the circle. 
    2. Second click on the map will set the outline point for the circle, create outline and add circle in list.
    3. To cancel circle creation, click on the "Cancel" button.

Note: Circles have a random color.

#### Circle list
After creating at least 1 circle, a list of circles will appear on the right side of the window. For each circle created, following information is displayed:
- Circle name (Consists of letter "C" and order of creation e.g. "C1")
- Color of the circle
- Circle center coordinates
- Circle radius

Every list item has a button to remove circle and checkbox to hide/show circle on the map.

## Height Map Console Application
This application creates a height map image from a given height map data file. :D
1. Open Program.cs
2. Set _filePath and _outputImagePath
3. Run application
