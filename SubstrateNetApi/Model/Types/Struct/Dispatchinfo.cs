﻿using System;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Enum;

namespace SubstrateNetApi.Model.Types.Struct
{
    public class DispatchInfo : StructType
    {
        public override string Name() => "DispatchInfo";

        private int _size;
        public override int Size() => _size;

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Weight = new U64();
            Weight.Decode(byteArray, ref p);


            DispatchClass = new EnumType<DispatchClass>();
            DispatchClass.Decode(byteArray, ref p);

            Pays = new EnumType<Pays>();
            Pays.Decode(byteArray, ref p);

            _size = p - start;
        }

        public U64 Weight { get; set; }
        public EnumType<DispatchClass> DispatchClass { get; set; }
        public EnumType<Pays> Pays { get; set; }
    }
}