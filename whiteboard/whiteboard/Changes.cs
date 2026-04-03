using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whiteboard
{
    //3/14
    //moved the saving functions to a different file to help orginazation
    //3/18
    //moved some of the delete functions to a new file 
    //renamed varible and cleaned up file for readability 
    //reworked the delete method to work when objects are reintalized after a save
    //3/19
    //finished delete method. it will now effect objects even after reloading and both bugs have been kills
    //the bugs were related to clicking setting off listeners for every item clicked leading to it messing up the for loop solved via a varible that tracks the current clicked box
    //another bug caused by spamming delete to fast caused it run the method multiple times crashing the app
    //started working on dynamic box size 
    //finished dynamic box size // click on two points subtracts each other then makes the box
    //changed the spawning placement to make it feel better
    //made it so if press m it will move the box to the new location
    //made it so if press r it will resize the box 
    //3/26
    //working on Console for release version - from laptop
    //rewrite some of the code to use switch statements instead of if else chain- from laptop
    //3/28
    //completely reorgnized files moving controls and box math to there own file to help with orginaztion - from laptop
    //3/31 - 4/2
    // fixed array bugs by going off the array length instead of box counter
    // redid controls to be more oginazed
    // created the move function which allows you to move objects around ( not true movement moves objects around the camera )

    
}
