namespace Properties {
   
    [System.Serializable]
    public class walk {
        public float speed = 2;
    }
    
    [System.Serializable]
    public class run {
        public float speed = 10;
    }
    
    [System.Serializable]
    public class jump {
        public float speed = 8;
        public float force = 3.0f;
        public float gravity = 12f;
    }

    [System.Serializable]
    public class axis {
        public float y = 0;
        public float x = 0;
        public float z = 0;
    }

    [System.Serializable]
    public class rotate {
        public float rotation = 0;
        public float speed = 4;
    }
    


}