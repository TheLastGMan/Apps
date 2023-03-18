using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetronomeMusicCreator.MusicStream
{
    enum NoteType : byte
    {
        //short hand
        S = 2,
        E = 4,
        Q = 8,
        H = 16,
        W = 32,
        //short hand rests
        SR = 2,
        ER = 4,
        QR = 8,
        HR = 16,
        WR = 32,
        //short hand (extended notes)
        SE = 3,
        EE = 6,
        QE = 12,
        HE = 24,
        //short hand rests
        SER = 3,
        EER = 6,
        QER = 12,
        HER = 24
    }
}
