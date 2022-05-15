<<<<<<< HEAD
<<<<<<< HEAD
﻿using Entities;
=======
﻿using Entities;
>>>>>>> 3fe4ef61862493bdcb29b21f9204f9c668744064
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Action = SmartDoorServer.Entities.Action;
namespace DL
{
    public interface IActionDL
    {
<<<<<<< HEAD
        List<TableRow> GetActionsByDates(int id, DateTime fromDate, DateTime toDate);
        void saveAttendance(Action[] table);
=======
        List<TableRow> GetActionsByDates(int id, DateTime fromDate, DateTime toDate);
        string detectFaces();
>>>>>>> 3fe4ef61862493bdcb29b21f9204f9c668744064
    }
=======
﻿using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Action = SmartDoorServer.Entities.Action;
namespace DL
{
    public interface IActionDL
    {
        List<TableRow> GetActionsByDates(int id, DateTime fromDate, DateTime toDate);
        void saveAttendance(Action[] table);
    }
>>>>>>> 7a5198517c309c3d1b84e6bad66afbe5165d43d4
}