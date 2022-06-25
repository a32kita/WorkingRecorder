using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WkRec.Entities;

namespace WkRec.Core
{
    public abstract class SerializerBase<TWorkingEntity> where TWorkingEntity : IWorkingEntity
    {
        // 非公開フィールド
        private Guid _guidHolder;
        private string _typeName;
        private string _fileNamePrefix;


        // コンストラクタ

        public SerializerBase()
        {
            this._typeName = typeof(TWorkingEntity).Name;
            this._fileNamePrefix = this._typeName + "_";
        }


        // 非公開メソッド

        private bool _isTargetJsonFile(string path)
        {
            var name = Path.GetFileNameWithoutExtension(path);
            name = name.Substring(this._fileNamePrefix.Length);

            return Guid.TryParse(name, out this._guidHolder);
        }

        private IEnumerable<string> _findTargetJsonFiles(string dirPath)
        {
            var files = Directory.GetFiles(dirPath, "*.json", SearchOption.TopDirectoryOnly);
            return files.Where(this._isTargetJsonFile);
        }

        private string _createFileName(TWorkingEntity obj)
        {
            return this._fileNamePrefix + obj.Identifier.ToString() + ".json";
        }


        // 公開メソッド

        public abstract Task SerializeTo(Stream outputStream, TWorkingEntity target);

        public virtual async Task SerializeTo(string dirPath, TWorkingEntity target)
        {
            var filePath = Path.Combine(dirPath, this._createFileName(target));
            using (var fs = File.OpenWrite(filePath))
            {
                await this.SerializeTo(fs, target);
            }
        }

        public virtual async Task SerializeAllTo(string dirPath, IEnumerable<TWorkingEntity> targets)
        {
            var files = this._findTargetJsonFiles(dirPath);
            foreach (var file in files)
            {
                File.Delete(file);
            }

            foreach (var target in targets)
            {
                await this.SerializeTo(dirPath, target);
            }
        }

        public abstract Task<TWorkingEntity> DeserializeFrom(Stream inputStream);

        public async Task<TWorkingEntity> DeserializeFrom(string filePath)
        {
            using (var fs = File.OpenRead(filePath))
            {
                return await this.DeserializeFrom(fs);
            }
        }

        public async Task<IEnumerable<TWorkingEntity>> DeserializeAllFrom(string dirPath)
        {
            var files = this._findTargetJsonFiles(dirPath);
            var result = new List<TWorkingEntity>();
            foreach (var file in files)
            {
                result.Add(await this.DeserializeFrom(file));
            }

            return result;
        }
    }
}
