using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WHCH.Api.Entities.Enums.CommonEnum;

namespace WHCH.Api.Entities
{

	public class LData
	{

        public System.String rtate { get; set; }
        public System.String banci { get; set; }
        public System.String krw { get; set; }
        public System.String pjz { get; set; }
        public System.String lz { get; set; }
        public System.String hjy { get; set; }

    }
}
