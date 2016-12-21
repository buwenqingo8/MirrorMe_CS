using System.IO;
using System.Xml;
using System;
using System.Web;

namespace Util
{
    /// <summary>
    /// XML文件操作
    /// </summary>
    public class XMLCore
    {
        public XMLCore(string filename)
        {
            _xmlFileName = filename;
        }

        public XMLCore(string filename, bool isopen)
            : this(filename)
        {
            if (isopen)
                Open();
        }

        public XMLCore(string filename, string basenode)
            : this(filename)
        {
            _xmlFileName = filename;
            _baseNode = basenode;
        }

        public XMLCore(string filename, string basenode, bool isIncludeResouce)
            : this(filename, basenode)
        {
            IsIncludeResouce = isIncludeResouce;
        }

        /// <summary>
        /// XML文件名
        /// </summary>
        private string _xmlFileName = "";
        public string XMLFileName
        {
            get { return _xmlFileName; }
            set { _xmlFileName = value; }
        }

        public string FileName
        {
            get { return _xmlFileName; }
        }
        /// <summary>
        /// 根结点名称
        /// </summary>
        private string _baseNode = "";
        public string BaseNode
        {
            get { return _baseNode; }
            set { _baseNode = value; }
        }

        /// <summary>
        /// 当前打开的XML文件
        /// </summary>
        private XmlDocument _currentDoc;
        public XmlDocument CurrentDoc
        {
            get { return _currentDoc; }
        }

        /// <summary>
        /// 文件是否打开
        /// </summary>
        private bool _isFileOpen = false;
        public bool IsFileOpen
        {
            get { return _isFileOpen; }
        }

        public bool IsIncludeResouce
        { get; set; }

        public void CreateXMLFile()
        {
            if (!File.Exists(FileName))
            {
                XmlNode node = _currentDoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                _currentDoc.AppendChild(node);
                XmlElement elem = GetElement(_baseNode);
                _currentDoc.AppendChild(elem);
                _currentDoc.Save(FileName);
            }
        }

        public bool Open()
        {
            if (_currentDoc == null)
                _currentDoc = new XmlDocument();

            CreateXMLFile();

            if (!_isFileOpen)
            {
                try
                {
                    if (IsIncludeResouce)
                    {
                        System.Reflection.Assembly assembly = GetType().Assembly;
                        Stream stream = assembly.GetManifestResourceStream(FileName);
                        _currentDoc.Load(stream);
                    }
                    else
                    {
                        _currentDoc.Load(FileName);
                    }
                    _isFileOpen = true;
                }
                catch
                {
                    return false;
                }

            }
            return true;

        }

        public bool Save()
        {
            return Save(FileName);
        }

        public bool Save(string savefilename)
        {
            if (_isFileOpen)
            {
                try
                {
                    if (IsIncludeResouce)
                    {
                        System.Reflection.Assembly assembly = GetType().Assembly;
                        Stream stream = assembly.GetManifestResourceStream(FileName);
                        _currentDoc.Save(stream);
                    }
                    else
                    {
                        _currentDoc.Save(savefilename);
                    }
                    return true;
                }
                catch
                {

                    return false;
                }
            }
            return false;
        }
        public bool Close()
        {
            if (_isFileOpen)
            {
                _currentDoc = null;
                _isFileOpen = false;

                return true;
            }
            return false;
        }

        public bool CreateXML(string basenode)
        {
            if (_isFileOpen)
            {
                XmlNode node = _currentDoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                _currentDoc.AppendChild(node);

                return true;
            }
            return false;
        }

        public bool CreateBaseNode()
        {
            if (_isFileOpen)
            {
                XmlElement elem = GetElement(_baseNode);
                _currentDoc.AppendChild(elem);

                return true;
            }
            return false;
        }

        public XmlElement GetBaseNode()
        {
            return GetNodeByName(_baseNode);
        }

        public XmlElement GetNodeByName(string nodename)
        {
            XmlNodeList node = _currentDoc.GetElementsByTagName(nodename);
            if (node.Count > 0)
                return (XmlElement)node[0];
            else
                return null;
        }

        public XmlElement GetNodeByName(string parnetelem, string nodename)
        {
            XmlElement elem = GetNodeByName(parnetelem);
            return GetNodeByName(elem, nodename);

        }
        public XmlElement GetNodeByName(XmlElement parentelem, string nodename)
        {
            if (parentelem != null)
            {
                XmlNodeList node = parentelem.GetElementsByTagName(nodename);
                if (node.Count > 0)
                    return (XmlElement)node[0];
            }
            return null;
        }

        public XmlElement AppendNode(XmlElement nodename)
        {
            XmlElement elem = GetNodeByName(_baseNode);
            return AppendNode(elem, nodename);
        }
        public XmlElement AppendNode(string parentname, string nodename)
        {
            XmlElement elem = GetNodeByName(parentname);
            return AppendNode(elem, nodename);
        }

        public XmlElement AppendNode(XmlElement parentelem, string nodename)
        {
            XmlElement elem = GetElement(nodename);
            return AppendNode(parentelem, elem);
        }

        public XmlElement AppendNode(XmlElement parentelem, XmlElement node)
        {
            if (parentelem != null)
                parentelem.AppendChild(node);
            return parentelem;
        }

        public XmlElement AppendNode(string parentname, XmlElement node)
        {
            XmlElement elem = GetNodeByName(parentname);
            return AppendNode(elem, node);
        }

        public XmlElement GetElement(string nodename)
        {
            XmlElement elem = _currentDoc.CreateElement("", nodename, "");
            return elem;
        }

        public XmlElement SetElementAttrib(XmlElement element, string attrib, string value)
        {
            element.SetAttribute(attrib, value);
            return element;
        }

        public static string getConfigNodeValue(String node, string path)
        {
           
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            try
            {
                XmlNode root = doc.SelectSingleNode(node);
                String temp = Convert.ToString(root);
                if (!string.IsNullOrEmpty(temp))
                    return doc.SelectSingleNode(node).InnerText;
                else
                    return "";
            }
            catch (Exception ef)
            {
                return "";
            }
        }

        public static void SaveXmlConfig(string strTarget, string strValue, string strSource)
        {

            //string xmlPath = HttpContext.Current.Server.MapPath(strSource);
            System.Xml.XmlDocument xdoc = new XmlDocument();

           // xdoc.Load(GetPublicKey.GetSysPath("XMLFile12_Request.xml"));

            xdoc.Load(strSource);
            XmlElement root = xdoc.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName(strTarget);
            elemList[0].InnerXml = strValue;
            xdoc.Save(strSource);
        }
    }
}
