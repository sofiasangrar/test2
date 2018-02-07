Module RandomColourGenerator 'returns a random colour from four preslected colours

    Public Function RandomColour(colourList)
        Randomize()
        Dim selection As Integer = Int(4 * Rnd()) 'a random colour from 0 to 3 is generated
        Return colourList(selection) 'a random element from the passed-in array of colours is returned
    End Function
End Module
