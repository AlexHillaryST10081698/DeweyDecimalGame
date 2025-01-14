using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalApplication.Classes
{
    internal class DeweyMultiLevelData
    {
        // Default Constructor 
        public DeweyMultiLevelData() 
        {

        }
        public List<DeweyNode> GetData()
        {
            return new List<DeweyNode>
            {
                new DeweyNode
                {
                    //level 1 entry
                    CallNumbers = "000",
                    Description = "Generalities",
                    Children = new List<DeweyNode>
                    {
                        new DeweyNode
                        {
                            //level 2 entry
                            CallNumbers = "010",
                            Description = "Bibliography",
                            Children = new List<DeweyNode>
                            {
                                //level 3 entry
                                new DeweyNode { CallNumbers = "011", Description = "Bibliographies" },
                                new DeweyNode { CallNumbers = "012", Description = "Bibliographies of individuals" },
                                new DeweyNode { CallNumbers = "013", Description = "Bibliographies of specific subjects" }
                            }
                        },
                        new DeweyNode
                        {
                            //level 2 entry
                            CallNumbers = "020",
                            Description = "Library and information sciences",
                            Children = new List<DeweyNode>
                            {
                                //level 3 entry
                                new DeweyNode { CallNumbers = "021", Description = "Library relationships" },
                                new DeweyNode { CallNumbers = "022", Description = "Administration of the physical plant" },
                                new DeweyNode { CallNumbers = "023", Description = "Personnel administration" }
                            }
                        },
                        new DeweyNode
                        {
                            //level 2 entry
                            CallNumbers = "030",
                            Description = "Encyclopedias & books of facts",
                            Children = new List<DeweyNode>
                            {
                                //level 3 entry
                                new DeweyNode { CallNumbers = "031", Description = "Encyclopedias in American English" },
                                new DeweyNode { CallNumbers = "032", Description = "Encyclopedias in English" },
                                new DeweyNode { CallNumbers = "033", Description = "Encyclopedias in other Germanic languages" }
                            }
                        }
                    }
                },
                new DeweyNode
                {
                    //level 1 entry
                    CallNumbers = "100",
                    Description = "Philosophy & psychology",
                    Children = new List<DeweyNode>
                    {
                        new DeweyNode
                        {
                            //level 2 entry
                            CallNumbers = "110",
                            Description = "Metaphysics",
                            Children = new List<DeweyNode>
                            {
                                //level 3 entry
                                new DeweyNode { CallNumbers = "111", Description = "Ontology" },
                                new DeweyNode { CallNumbers = "112", Description = "Cosmology" },
                                new DeweyNode { CallNumbers = "113", Description = "Time" }
                            }
                        },
                        new DeweyNode
                        {
                            //level 2 entry
                            CallNumbers = "120",
                            Description = "Epistemology",
                            Children = new List<DeweyNode>
                            {
                                //level 3 entry
                                new DeweyNode { CallNumbers = "121", Description = "Theory of knowledge" },
                                new DeweyNode { CallNumbers = "122", Description = "Doubt" },
                                new DeweyNode { CallNumbers = "123", Description = "Belief" }
                            }
                        },
                        new DeweyNode
                        {
                            //level 2 entry
                            CallNumbers = "130",
                            Description = "Paranormal phenomena",
                            Children = new List<DeweyNode>
                            {
                                //level 3 entry
                                new DeweyNode { CallNumbers = "131", Description = "Parapsychology & occultism" },
                                new DeweyNode { CallNumbers = "132", Description = "No longer used—formerly Mental derangements" },
                                new DeweyNode { CallNumbers = "133", Description = "Specific topics in parapsychology & occultism" }
                            }
                        }
                    }
                },
                new DeweyNode
                {
                    //level 1 entry
                    CallNumbers = "200",
                    Description = "Religion",
                    Children = new List<DeweyNode>
                    {
                        new DeweyNode
                        {
                            //level 2 entry
                            CallNumbers = "210",
                            Description = "Philosophy & theory of religion",
                            Children = new List<DeweyNode>
                            {
                                //level 3 entry
                                new DeweyNode { CallNumbers = "211", Description = "Concepts of God" },
                                new DeweyNode { CallNumbers = "212", Description = "Existence of God" },
                                new DeweyNode { CallNumbers = "213", Description = "Attributes of God" }
                            }
                        },
                        new DeweyNode
                        {
                            //level 2 entry
                            CallNumbers = "220",
                            Description = "The Bible",
                            Children = new List<DeweyNode>
                            {
                                //level 3 entry
                                new DeweyNode { CallNumbers = "221", Description = "Old Testament" },
                                new DeweyNode { CallNumbers = "222", Description = "Historical books of the Old Testament" },
                                new DeweyNode { CallNumbers = "223", Description = "Poetic books of the Old Testament" }
                            }
                        },
                        new DeweyNode
                        {
                            //level 2 entry
                            CallNumbers = "230",
                            Description = "Christianity",
                            Children = new List<DeweyNode>
                            {
                                //level 3 entry
                                new DeweyNode { CallNumbers = "231", Description = "God; Unity & Trinity" },
                                new DeweyNode { CallNumbers = "232", Description = "Jesus Christ & his family" },
                                new DeweyNode { CallNumbers = "233", Description = "Humankind" }
                            }
                        }
                    }
                },
                new DeweyNode
                {
                    //level 1 entry
                    CallNumbers = "300",
                    Description = "Social sciences",
                    Children = new List<DeweyNode>
                    {
                        new DeweyNode
                        {
                            //level 2 entry
                            CallNumbers = "310",
                            Description = "Statistics",
                            Children = new List<DeweyNode>
                            {
                                //level 3 entry
                                new DeweyNode { CallNumbers = "311", Description = "Collections of statistics" },
                                new DeweyNode { CallNumbers = "312", Description = "Population" },
                                new DeweyNode { CallNumbers = "313", Description = "Specific aspects of statistics" }
                            }
                        },
                        new DeweyNode
                        {
                            //level 2 entry
                            CallNumbers = "320",
                            Description = "Political science",
                            Children = new List<DeweyNode>
                            {
                                //level 3 entry
                                new DeweyNode { CallNumbers = "321", Description = "Systems of governments" },
                                new DeweyNode { CallNumbers = "322", Description = "Relation of state to organized groups" },
                                new DeweyNode { CallNumbers = "323", Description = "Civil & political rights" }
                            }
                        },
                        new DeweyNode
                        {
                            //level 2 entry
                            CallNumbers = "330",
                            Description = "Economics",
                            Children = new List<DeweyNode>
                            {
                                //level 3 entry
                                new DeweyNode { CallNumbers = "331", Description = "Labor economics" },
                                new DeweyNode { CallNumbers = "332", Description = "Financial economics" },
                                new DeweyNode { CallNumbers = "333", Description = "Land economics" }
                            }
                        }
                    }
                },
                new DeweyNode
                {
                    //Level 1 Entry
                    CallNumbers = "400",
                    Description = "Language",
                    Children = new List<DeweyNode>
                    {
                        new DeweyNode
                        {
                            //Level 2 Entry 
                            CallNumbers = "410",
                            Description = "Linguistics",
                            Children = new List<DeweyNode>
                            {
                                //Level 3 Entry
                                new DeweyNode { CallNumbers = "411", Description = "Writing systems" },
                                new DeweyNode { CallNumbers = "412", Description = "Etymology" },
                                new DeweyNode { CallNumbers = "413", Description = "Dictionaries" }
                            }
                        },
                        new DeweyNode
                        {
                            // Level 2 Entry 
                            CallNumbers = "420",
                            Description = "English & Old English languages",
                            Children = new List<DeweyNode>
                            {
                                //Level 3 Entry
                                new DeweyNode { CallNumbers = "421", Description = "English writing system & phonology" },
                                new DeweyNode { CallNumbers = "422", Description = "English etymology" },
                                new DeweyNode { CallNumbers = "423", Description = "English dictionaries" }
                            }
                        },
                        new DeweyNode
                        {
                            //Level 2 Entry
                            CallNumbers = "430",
                            Description = "Germanic languages; German",
                            Children = new List<DeweyNode>
                            {
                                //Level 3 Entry
                                new DeweyNode { CallNumbers = "431", Description = "Writing systems" },
                                new DeweyNode { CallNumbers = "432", Description = "Etymology" },
                                new DeweyNode { CallNumbers = "433", Description = "Dictionaries" }
                            }
                        }
                    }
                },
                new DeweyNode
                {
                    //Level 2 Entry 
                    CallNumbers = "500",
                    Description = "Natural sciences & mathematics",
                    Children = new List<DeweyNode>
                    {
                        new DeweyNode
                        {
                            // Level 3 Entry 
                            CallNumbers = "510",
                            Description = "Mathematics",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "511", Description = "General principles of mathematics" },
                                new DeweyNode { CallNumbers = "512", Description = "Algebra & number theory" },
                                new DeweyNode { CallNumbers = "513", Description = "Arithmetic" }
                            }
                        },
                        new DeweyNode
                        {
                            //Levell 2 Entry
                            CallNumbers = "520",
                            Description = "Astronomy & allied sciences",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "521", Description = "Celestial mechanics" },
                                new DeweyNode { CallNumbers = "522", Description = "Techniques, procedures, apparatus in astronomy" },
                                new DeweyNode { CallNumbers = "523", Description = "Specific celestial bodies & phenomena" }
                            }
                        },
                        new DeweyNode
                        {
                            CallNumbers = "530",
                            Description = "Physics",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "531", Description = "Classical mechanics" },
                                new DeweyNode { CallNumbers = "532", Description = "Fluid mechanics; Liquid mechanics" },
                                new DeweyNode { CallNumbers = "533", Description = "Gas mechanics" }
                            }
                        }
                    }
                },
                new DeweyNode
                {
                    CallNumbers = "600",
                    Description = "Applied Science",
                    Children = new List<DeweyNode>
                    {
                        new DeweyNode
                        {
                            CallNumbers = "610",
                            Description = "Medicine & health",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "611", Description = "Human anatomy" },
                                new DeweyNode { CallNumbers = "612", Description = "Human physiology" },
                                new DeweyNode { CallNumbers = "613", Description = "Personal health & safety" }
                            }
                        },
                        new DeweyNode
                        {
                            CallNumbers = "620",
                            Description = "Engineering",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "621", Description = "Applied physics" },
                                new DeweyNode { CallNumbers = "622", Description = "Mining & related operations" },
                                new DeweyNode { CallNumbers = "623", Description = "Military & nautical engineering" }
                            }
                        },
                        new DeweyNode
                        {
                            CallNumbers = "630",
                            Description = "Agriculture & related technologies",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "631", Description = "Techniques, equipment, materials in agriculture" },
                                new DeweyNode { CallNumbers = "632", Description = "Plant injuries, diseases, pests" },
                                new DeweyNode { CallNumbers = "633", Description = "Field & plantation crops" }
                            }
                        }
                    }
                },
                new DeweyNode
                {
                    CallNumbers = "700",
                    Description = "Arts & recreation",
                    Children = new List<DeweyNode>
                    {
                        new DeweyNode
                        {
                            CallNumbers = "710",
                            Description = "Landscaping & area planning",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "711", Description = "Area planning" },
                                new DeweyNode { CallNumbers = "712", Description = "Landscape architecture" },
                                new DeweyNode { CallNumbers = "713", Description = "Landscape design & gardening" }
                            }
                        },
                        new DeweyNode
                        {
                            CallNumbers = "720",
                            Description = "Architecture",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "721", Description = "Architectural planning" },
                                new DeweyNode { CallNumbers = "722", Description = "Architecture to ca. 300" },
                                new DeweyNode { CallNumbers = "723", Description = "Architecture from ca. 300 to 1399" }
                            }
                        },
                        new DeweyNode
                        {
                            CallNumbers = "730",
                            Description = "Sculpture, ceramics & metalwork",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "731", Description = "Sculpture" },
                                new DeweyNode { CallNumbers = "732", Description = "Sculpture in stone & bronze" },
                                new DeweyNode { CallNumbers = "733", Description = "Greek, Etruscan, Roman sculpture" }
                            }
                        }
                    }
                },
                new DeweyNode
                {
                    CallNumbers = "800",
                    Description = "Literature",
                    Children = new List<DeweyNode>
                    {
                        new DeweyNode
                        {
                            CallNumbers = "810",
                            Description = "American literature in English",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "811", Description = "Poetry" },
                                new DeweyNode { CallNumbers = "812", Description = "Drama" },
                                new DeweyNode { CallNumbers = "813", Description = "Fiction" }
                            }
                        },
                        new DeweyNode
                        {
                            CallNumbers = "820",
                            Description = "English & Old English literatures",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "821", Description = "Poetry" },
                                new DeweyNode { CallNumbers = "822", Description = "Drama" },
                                new DeweyNode { CallNumbers = "823", Description = "Fiction" }
                            }
                        },
                        new DeweyNode
                        {
                            CallNumbers = "830",
                            Description = "Literatures of Germanic languages",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "831", Description = "Poetry" },
                                new DeweyNode { CallNumbers = "832", Description = "Drama" },
                                new DeweyNode { CallNumbers = "833", Description = "Fiction" }
                            }
                        }

                    }
                },
                new DeweyNode
                {
                    CallNumbers = "900",
                    Description = "History & geography",
                    Children = new List<DeweyNode>
                    {
                        new DeweyNode
                        {
                            CallNumbers = "910",
                            Description = "Geography & travel",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "911", Description = "Historical geography" },
                                new DeweyNode { CallNumbers = "912", Description = "Graphic representations of the earth" },
                                new DeweyNode { CallNumbers = "913", Description = "Ancient world" }
                            }
                        },
                        new DeweyNode
                        {
                            CallNumbers = "920",
                            Description = "Biography & genealogy",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "921", Description = "Of philosophy" },
                                new DeweyNode { CallNumbers = "922", Description = "Of religion" },
                                new DeweyNode { CallNumbers = "923", Description = "Of social sciences" }
                            }
                        },
                        new DeweyNode
                        {
                            CallNumbers = "930",
                            Description = "History of ancient world (to ca. 499)",
                            Children = new List<DeweyNode>
                            {
                                new DeweyNode { CallNumbers = "931", Description = "China to 420" },
                                new DeweyNode { CallNumbers = "932", Description = "Egypt to 640" },
                                new DeweyNode { CallNumbers = "933", Description = "Greece to 323" }
                            }
                        }
                    }
                }
            };
    
        }
    
    }
}
//--------------------------------------------------------------------------------End of File --------------------------------------------------------------------------------------------------------------------//


